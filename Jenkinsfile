pipeline {
    
    stages {


        stage('Test') {
            steps {
                script {
                    try {
                        sh 'docker ps'
                    } catch (Exception e) {
                        echo "Testing failed"
                    }
                }
            }
        }
    }

  
}
