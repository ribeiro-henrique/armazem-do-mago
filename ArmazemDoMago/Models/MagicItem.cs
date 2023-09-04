namespace ArmazemDoMago.Models {
    public class MagicItem {

        // Identificador único do item
        public int Id { get; set; }

        // Nome do item mágico
        public string Name { get; set; }

        // Descrição do item mágico
        public string Description { get; set; }

        // Quantidade de unidades do item
        public double Quantity { get; set; }

        // Valor que representa o poder mágico do item
        public int MagicPower { get; set; }
    }
}
