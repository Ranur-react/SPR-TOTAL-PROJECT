pipeline {
    agent any
    environment {
        // Set environment variables for Docker Hub credentials
        DOCKERHUB_USER = 'ranur'
        imageName = "ranur/mssql:22.0"
        BRANCH = "db1.0"
        NODE = "sql1"
        PORT = "1433"
        PORT_PUBLISH = "1433"
        ROOTDIR = "SPR-TOTAL-PROJECT"
        GITPATHREPO = "github.com/Ranur-react/SPR-TOTAL-PROJECT.git" 
        HOSTNAME = "sqldev"
        SUBDIRECTORY = "7. DB"
    }
    
    stages {
        stage('Set MSSQL Password') {
            steps {
                script {
                    withCredentials([string(credentialsId: 'MSSQL_SA_PASSWORD', variable: 'SA_PASWD')]) {
                        env.PASSWD = SA_PASWD
                    }
                }
            }
        }

        stage('Clone or Pull') {
            steps {
                script {
                   // Fetch GitHub token from Jenkins credentials
                    withCredentials([string(credentialsId: 'GITOKEN', variable: 'GITHUB_TOKEN')]) {
                        if (fileExists(DIR)) {
                            dir(DIR) {
                                sh 'git fetch'
                                sh "git checkout ${BRANCH}"
                                sh "git pull origin ${BRANCH}"
                            }
                        } else {
                            // Use GitHub token in the git clone command
                            sh "git clone -b ${BRANCH} https://${GITHUB_TOKEN}${GITPATHREPO}"
                        }
                    }
                }
            }
        }

        stage('Container Renewal') {
            steps {
                script {
                    try {
                        sh "docker stop ${NODE}"
                        sh "docker rm ${NODE}"
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
                script {
                    try {
                        dir(env.ROOTDIR) {
                            dir(env.SUBDIRECTORY) {
                                sh "docker build -t ${imageName} ."
                            }
                        }
                    } catch (Exception e) {
                        echo "Docker image ${imageName} was not built due to: ${e}"
                    }
                }
            }
        }

        stage('Run New Container') {
            steps {
                script {
                    sh "docker run -p ${PORT_PUBLISH}:${PORT} --name ${NODE} --hostname ${HOSTNAME} -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=${PASSWD}' -d ${imageName}"
                }
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
