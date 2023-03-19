namespace PagingDemo.Paging {
    static class PagingUtil {
        static readonly List<int> list = new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};    

        internal static PagingMessage GetListWithPage(){
            return GetListWithPage(new PagingMessage(1,4));
        }
        internal static PagingMessage GetListWithPage(PagingMessage message){
            if(message is null){
                message = new PagingMessage(1,4);
            }
            int maxPage = list.Count / message.PageSize;
            if((list.Count % message.PageSize) != 0){
                maxPage++;
            }
            
            message.MaxPageNumber = maxPage;
            message.PagedList = list.Skip<int>((message.CurrentPage-1)*message.PageSize).Take(message.PageSize);

            return message;
        }
    }

    class PagingMessage {
        public int PageSize {get;set;} = 4;
        public int CurrentPage {get; set;} = 1;
        public int MaxPageNumber {get; set;} = 3;

        public IEnumerable<int> PagedList {get; internal set;}

        public PagingMessage(){
            PagedList = new List<int>();
        }

        internal PagingMessage(int currentPage, int pageSize){
            PageSize = pageSize;
            PagedList = new List<int>();
            CurrentPage = currentPage;
        }
    } 
}