export class ClienteFC {
  Id: string;
  Cliente_id: string;
  Nome: string;
  Linha_CAP: string;
  Mercado_CAP: string;
  Cor: string;
  Modal: string;
  Mercado_VF: string;
  Pais: string;
  MercadoCAPId: string;
  MercadoVFId: string;
  LinhaCAPId: string;
  MercadoCAP: string;
  MercadoVF: string;
  LinhaCAP: string;
  percentual: string;
}

// Id	Cliente_id	Nome	                        Linha_CAP	Mercado_CAP	Cor	  Modal	Mercado_VF	Pais	MercadoCAPId	MercadoVFId
// 1	5019	      Acobras Acos Brasileiro Ltda	OutrosMI	MI	        NULL	NULL	NULL	      NULL	0	            0
// 2	0	          AÇOBRIL COMERCIAL DE AçO LTDA	OutrosMI	MI	        NULL	NULL	NULL	      NULL	0	            0


export class MercadoCAP {  //MercadoCAP = Contry
  MercadoCAPId: string;
  Mercado_CAP: string;
}

export class MercadovfFC {  //MercadoVF = State
  MercadoVFId: string;
  Mercado_VF: string;
  MercadoCAPId: string;
}

export class LinhaCAP {  //LinhaCAP = City
  LinhaCAPId: string;
  Linha_CAP: string;
  MercadoCAPId: string;
  MercadoVFId: string;
}
