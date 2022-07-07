// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

// Compilar para DEV
// ng build --configuration=dev
//Caminho do servidor terbrdspm01v01 IIS
//C:\inetpub\wwwroot\CargaForcast_API
//C:\inetpub\wwwroot\CargaForcast
//C:\inetpub\wwwroot\CargaForcast1

export const environment = {
  production: false,
  apiUrl: "http://localhost:51600",
  rootUrl: 'http://localhost:4200',
  ambiente: "DESENVOLVIMENTO1",
  timeSession: 900000,
  backendUrl: 'http://localhost:51600',
  BASE_URL: 'http://localhost:51600'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
