
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface ICondizioniPagamentoManager
    {
        public List<CondizionePagamento> GetCondizioniPagamento();

        public string AddCondizionePagamento(CondizionePagamento rk);

        public string UpdateCondizionePagamento(string IDCondizione, CondizionePagamento rk);

        public CondizionePagamento GetCondizionePagamento(string IdCondizione);

        public CondizionePagamento DeleteCondizionePagamento(string IdCondizione);
    }
}