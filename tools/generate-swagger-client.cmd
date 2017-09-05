rmdir /s /q %~dp0\..\src\Boundlss.Coaching\App\service

java -jar %~dp0\swagger-codegen-cli-2.2.3.jar generate -i http://localhost:6234/swagger/docs/v1 -l typescript-angular2 -o %~dp0\..\src\Carsales.Web\Carsales.Web\ClientApp\app\api