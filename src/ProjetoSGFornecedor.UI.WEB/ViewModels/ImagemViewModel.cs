using System;

namespace ProjetoSGFornecedor.UI.WEB.ViewModels
{
    public class ImagemViewModel
    {
        public Guid IdImagem { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CaminhoDaImagem { get; set; }

    }
}
