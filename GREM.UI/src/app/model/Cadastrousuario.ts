export class Cadastrousuario {
  Id: string;
  Usuario: string;
  Email: string;
  Password: string;
  IsAdmin: string;
}

export class MercadoCAP {
  MercadoCAPId: string;
  Mercado_CAP: string;
}

export class MercadoVF {
  MercadoVFId: string;
  Mercado_VF: string;
  MercadoCAPId: string;
}

export class City {
  Cityid: string;
  CityName: string;
  MercadoCAPId: string;
  MercadoVFId: string;

}
