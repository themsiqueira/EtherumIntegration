using Nethereum.Contracts;
using Nethereum.Web3;

namespace Integration.Models
{
    public class EtherumConnection
    {
        public string Url { get; set; }

        public string Adress { get; set; }

        public string Abi { get; set; }

        public Web3 Conection { get; set; }

        public Contract ContractInstance { get; set; }

        public void OpenConnection()
        {
            this.Conection = new Web3(this.Url);
        }

        public void GetContract()
        {
            this.ContractInstance = this.Conection.Eth.GetContract(this.Abi, this.Adress);
        }
    }
}