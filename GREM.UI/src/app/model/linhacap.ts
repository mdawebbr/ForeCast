export class Linhacap {
  LinhaCAPId: string;
  Linha_CAP: string;
  //LastName: string;
  //DateofBirth: Date;
  //EmailId: string;
  //Gender: string;
  MercadoCAPId: string;
  MercadoVFId: string;
  //Cityid: string;
  //Address: string;
  //Pincode: string;
  MercadoCAP: string;
  MercadoVF: string;
  //City: string;
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
