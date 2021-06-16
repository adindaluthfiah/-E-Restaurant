namespace edToast
{
    public class Total_pesan : Form1
    {
        public static double total(int pesan1, int pesan2, int pesan3, int pesan4)
        {
            int total1, total2, total3, total4;

            total1 = 15000 * pesan1;
            total2 = 22000 * pesan2;
            total3 = 20000 * pesan3;
            total4 = 25000 * pesan4;

            subTotal = total1 + total2 + total3 + total4;
            double pajak = total1 * 0.05 + total2 * 0.05 + total3 * 0.05 + total4 * 0.05;
            totalSemua = subTotal + pajak;
            return totalSemua;
        }
    }
}
