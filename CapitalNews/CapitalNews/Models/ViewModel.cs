namespace CapitalNews.Models
{
    public class CategoriasViewModel
    {
        public int Id { get; set; }
        public string CategoriaNome { get; set; }
    }

    public class FotografiasViewModel
    {
        public int Id { get; set; }
        public string Descritor { get; set; }
        public string Imagem { get; set; }
    }

    public class JornalistasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }

    public class NoticiasViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Body { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
        public string Fotografia { get; set; }
        public string Jornalista { get; set; }
    }

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}