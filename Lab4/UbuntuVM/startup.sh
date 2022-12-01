cd /var/baget/app
sudo kill -9 $(sudo lsof -t -i:8081)
dotnet BaGet.dll --urls http://*:8081