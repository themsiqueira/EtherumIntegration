using Integration.Models;
using Nethereum.Hex.HexTypes;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Integration.Business
{
    public class DataBusiness
    {
        public string Add(dynamic Data)
        {
            EtherumConnection etherumConnection = SetupConnectionAndGetContract();

            return SaveOnBlockChain(etherumConnection, Data);
        }

        public EtherumConnection SetupConnectionAndGetContract()
        {
            EtherumConnection etherumConnection = new EtherumConnection();
            etherumConnection.Url = "Aqui vai a url da sua rede blockchain";
            etherumConnection.Adress = "Aqui vai o endereço do seu smart contract";
            etherumConnection.Abi = "Aqui vai a abi do seu smart contract";
            etherumConnection.OpenConnection();
            etherumConnection.GetContract();

            return etherumConnection;
        }

        public string SaveOnBlockChain(EtherumConnection etherumConnection, string Data)
        {
            try
            {
                string accountAddress = "Aqui vai o endereço da conta na qual contém o gás para transação";
                Task<HexBigInteger> gas = etherumConnection.ContractInstance.GetFunction("save").EstimateGasAsync(Data);
                gas.Wait();
                HexBigInteger value = new HexBigInteger(new BigInteger(0));
                Task<string> save = etherumConnection.ContractInstance.GetFunction("save").SendTransactionAsync(accountAddress, gas.Result, value, Data);
                save.Wait();
                return save.Result;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public dynamic Get()
        {
            EtherumConnection etherumConnection = SetupConnectionAndGetContract();
            dynamic DataFromBLock = GetFromBlockchains(etherumConnection);

            return DataFromBLock;
        }

        public dynamic GetFromBlockchains(EtherumConnection etherumConnection)
        {
            Task<string> DataFromBlock = etherumConnection.ContractInstance.GetFunction("get").CallAsync<string>();
            DataFromBlock.Wait();
            dynamic Result = DataFromBlock.Result;

            return Result;
        }
    }
}