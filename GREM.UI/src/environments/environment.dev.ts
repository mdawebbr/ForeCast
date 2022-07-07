// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

// Compilar para DEV
// ng build --configuration=dev
// Caminho do servidor terbrdspm01v01 IIS
// C:\inetpub\wwwroot\CargaForcast_API
// C:\inetpub\wwwroot\CargaForcast
// C:\inetpub\wwwroot\CargaForcast1

export const environment = {
  production: false,

  apiUrl: 'http://terbrdspm01v01.ternium.techint.net:8080/webstart_api',
  rootUrl: 'http://terbrdspm01v01.ternium.techint.net:8080/webstart/',

  //apiUrl: "http://192.168.0.21:8080/webstart_api",
  //rootUrl: 'http://192.168.0.21:8080/webstart/',

  backendUrl: 'http://terbrdspm01v01.ternium.techint.net:8080/webstart_api',
  BASE_URL: 'http://terbrdspm01v01.ternium.techint.net:8080/webstart_api',

  ambiente: "DESENVOLVIMENTO",
  timeSession: 900000
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
