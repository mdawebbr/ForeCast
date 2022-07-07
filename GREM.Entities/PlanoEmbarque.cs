using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class PlanoEmbarque
    {
        public PlanoEmbarque()
        {
        }
        [Key]
        public int Id { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public float Valor { get; set; }
        public int PEA_Ano { get; set; }
        public int MeioTransporte_Id { get; set; }
        public int Cliente_Id { get; set; }
        public string Pacote { get; set; }
        public Cliente Cliente {get;set;}
        public MeioTransporte MeioTransporte { get; set; }
    }


    public class MeioTransporte
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
    }

    public class PlanoEmbarqueQuadrimestre
    {
        public int Chave { get; set; }
        public string DTInicio { get; set; }
        public string DTFim { get; set; }
    } 

    public class PlanoEmbarqueAdd
    {
        public List<int> cliente_id { get; set; }
        public int transporte_id { get; set; }
        public List<int> dias { get; set; }
        public List<int> meses { get; set; }
        public int peaAno { get; set; }
        public float valor { get; set; }
    }

    public class PlanoEmbarqueCSV
    {
        public string Cliente { get; set; }
        public string Data { get; set; }
        public string Pacote { get; set; }
        public string Valor { get; set; }
    }
    //ToDo Mauro
    public class PlanoEmbarqueIR
    {
        public string Cliente { get; set; }
        public string Data { get; set; }
        public string Pacote { get; set; }
        public string Contador  { get; set; }         //a partir de 9001 caso ""OVE"" Senão a partir de 1"	
        public string placas1 { get; set; }          //"Placas_Linhas_CAP-NA-CUS ou Placas_Linhas_CAP-NA-OVE"
        public string placas2 { get; set; }          //Valor inserido de demanda
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public string Zero { get; set; }              //"Set ""0"" constante"
        public string Data1 { get; set; }
        public string QtdDiasMes { get; set; }        //Quantidade de dias do mês
        public string NAConstante { get; set; }       //"Set ""NA"" constante"
        public string Venda_Reap { get; set; }        //"Caso seja ""P/ Venda"" ou ""P/ Reaproveitamento""  --> recebe ""OVE"" Senão Set ""Cus"""
        public string Data_inserida { get; set; }     //"Data inserida //Formato AAAAMMDD"
        public string Data2 { get; set; }             //Ano/Mês inserido no Input Panel
        public string PlacaLinha_CAP1 { get; set; }
        public string Target { get; set; }            //Set "Target"	
        public string PlacaLinha_CAP2 { get; set; }
        public string Quadrimestre { get; set; }      //Quadrimestre referente a data inserida no Input Panel de acordo com o PEA
        public string PlacaLinha_CAP3 { get; set; }
        public string PlacaLinha_CAP4 { get; set; }
        public string PrimeiraOvr { get; set; }       //"Caso cliente seja ""P/ Venda"" ou ""P/ Reaproveitamento"" --> recebe ""Ovr"" Senão Set ""Primeira"""	
        public string Mercado { get; set; }           //Mercado
        public string US { get; set; }                //Default "US"
        public string Data3 { get; set; }             //Data inserida na aplicação
        public string Data4 { get; set; }
        public string Cor { get; set; }
        public string Data5 { get; set; }
        public string Data6 { get; set; }
    }

    public class PlanoEmbarqueQ
    {
        public string Cliente { get; set; }
        public string Data { get; set; }
        public string Pacote { get; set; }
        public string Contador { get; set; }         //a partir de 9001 caso ""OVE"" Senão a partir de 1"	
        public string placas1 { get; set; }          //"Placas_Linhas_CAP-NA-CUS ou Placas_Linhas_CAP-NA-OVE"
        public string placas2 { get; set; }          //Valor inserido de demanda
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public string Zero { get; set; }              //"Set ""0"" constante"
        public string Data1 { get; set; }
        public string QtdDiasMes { get; set; }        //Quantidade de dias do mês
        public string NAConstante { get; set; }       //"Set ""NA"" constante"
        public string Venda_Reap { get; set; }        //"Caso seja ""P/ Venda"" ou ""P/ Reaproveitamento""  --> recebe ""OVE"" Senão Set ""Cus"""
        public string Data_inserida { get; set; }     //"Data inserida //Formato AAAAMMDD"
        public string Data2 { get; set; }             //Ano/Mês inserido no Input Panel
        public string PlacaLinha_CAP1 { get; set; }
        public string Target { get; set; }            //Set "Target"	
        public string PlacaLinha_CAP2 { get; set; }
        public string Quadrimestre { get; set; }      //Quadrimestre referente a data inserida no Input Panel de acordo com o PEA
        public string PlacaLinha_CAP3 { get; set; }
        public string PlacaLinha_CAP4 { get; set; }
        public string PrimeiraOvr { get; set; }       //"Caso cliente seja ""P/ Venda"" ou ""P/ Reaproveitamento"" --> recebe ""Ovr"" Senão Set ""Primeira"""	
        public string Mercado { get; set; }           //Mercado
        public string US { get; set; }                //Default "US"
        public string Data3 { get; set; }             //Data inserida na aplicação
        public string Data4 { get; set; }
        public string Cor { get; set; }
        public string Data5 { get; set; }
        public string Data6 { get; set; }
    }

    public class PlanoEmbarqueAlterar
    {
        public int id { get; set; }
        public int transporte_id { get; set; }
        public float valor { get; set; }
        public string pacote { get; set; }
    }

    public class PlanoEmbarqueVM
    {
        public int Dia { get; set; }
        public int Mes { get; set; }

        public float ValorTotalDia { get; set; }
        
        public int PEA_Ano { get; set; }

        public List<ClientePlanoEmbarque> ListaCliente { get; set; }


    }

    public class PlanoEmbarqueTodosMesesVM
    {
        public int Dia { get; set; }

        public float ValorTotalDia { get; set; }

        public int PEA_Ano { get; set; }

        public List<MesesPlanoEmbarque> ListaMes { get; set; }


    }

    public class MesesPlanoEmbarque
    {
        public int Mes { get; set; }
        public float Valor { get; set; }
        public float ValorDia { get; set; }
        public bool TemValor { get; set; }
    }

    public class ClientePlanoEmbarque
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public string ClienteValor { get; set; }
        public MeioTransporte MeioTransporte { get; set; }
        public Cliente Cliente { get; set; }
        public string Pacote { get; set; }
        public string Cor { get; set; }
    }
}
