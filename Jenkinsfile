pipeline {
    agent any
    environment {
        // Set environment variables for Docker Hub credentials
        DOCKERHUB_USER = 'ranur'
        imageName = "ranur/mssql:22.0"
        BRANCH = "db1.0"
        NODE="sql1"
        PORT="1433 "
        PORT_PULISH="1433"
        ROOTDIR="SPR-TOTAL-PROJECT"
        REPO="https://github.com/Forber-Technology-Indonesia/frontend-toserba-pos.git"
        HOSTNAME="sqldev"
        withCredentials([string(credentialsId: 'MSSQL_SA_PASSWORD', variable: 'SA_PASWD')]) {
            PASSWD=SA_PASWD
        }
        SUBDIRECTORY="7. DB"
    }
    
    stages {
        stage('Clone or Pull') {
            steps {
                script {
                    if (fileExists(${ROOTDIR})) {
                        dir(${ROOTDIR}) {
                            sh 'git fetch'
                            sh 'git checkout ${BRANCH}'
                            sh 'git pull origin ${BRANCH}'
                        }
                    } else {
                        sh 'git clone -b ${BRANCH} ${REPO}'
                    }
                }
            }
        }

        stage('Container Renewal') {
            steps {
                script {
                    try {
                        sh 'docker stop ${NODE}'
                        sh 'docker rm ${NODE}'
                    } catch (Exception e) {
                        echo "Container ${NODE} was not running or could not be stopped/removed: ${e}"
                    }
                }
            }
        }

        stage('Image Remove') {
            steps {
                script {
                    try {
                        sh "docker rmi ${imageName}"
                    } catch (Exception e) {
                        echo "Image ${imageName} could not be removed: ${e}"
                    }
                }
            }
        }
        stage('Build Docker Image') {
            steps {
                try {
                    dir(${ROOTDIR}) 
                        {
                           dir(${SUBDIRECTORY}) 
                                {
                                    sh "docker build -t ${imageName} ."
                                }
                        }
                    } catch (Exception e) {
                        echo "Docker ${imageName} was not build with reason: ${e}"
                    }
            }
        }

        stage('Run New Container') {
            steps {
                
                sh "docker run -p ${PORT_PULISH}:${PORT} --name ${NODE} --hostname ${HOSTNAME} -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=${PASSWD}' -d ${imageName}"
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    withCredentials([string(credentialsId: 'DOCKERHUB_TOKEN', variable: 'DOC_PWD')]) {
                        sh "echo ${DOC_PWD} | docker login -u ${DOCKERHUB_USER} --password-stdin"
                    }
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    sh "docker push ${imageName}"
                }
            }
        }
    }

    post {
        always {
            echo 'This will always run'
        }
        success {
            echo 'Pipeline was successful!'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}
