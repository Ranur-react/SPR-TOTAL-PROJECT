pipeline {
    agent any
    environment {
        // Set environment variables for Docker Hub credentials
        DOCKERHUB_USER = 'ranur'
        imageName = "ranur/fe-spr:8.0"
        BRANCH = "master"
        NODE="net1"
        PORT="4001"
        PORT_PULISH="4001"
        ROOTDIR="SPR-TOTAL-PROJECT"
        REPO="https://github.com/Forber-Technology-Indonesia/frontend-toserba-pos.git"
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
                            sh "docker build -t ${imageName} ."
                        }
                    } catch (Exception e) {
                        echo "Docker ${imageName} was not build with reason: ${e}"
                    }
            }
        }

        stage('Run New Container') {
            steps {
                sh "docker run -d --name ${NODE} -p ${PORT_PULISH}:${PORT} ${imageName}"
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
