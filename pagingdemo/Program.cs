using PagingDemo.Paging;


namespace PagingDemo {
    class Program {
        static void Main(string[] args) {
            PagingMessage message = new PagingMessage();

            for (int i = 1; i <= message.MaxPageNumber; i++) {
                message.CurrentPage = i;
                message = PagingUtil.GetListWithPage(message);
                
                foreach(var item in message.PagedList){
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}