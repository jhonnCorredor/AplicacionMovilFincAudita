namespace Entity.Dto
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public Boolean status { get; set; }
        public string message { get; set; }
        public Object content { get; set; }

        public ApiResponse(Object content, Boolean status, string message, T data) 
        { 
            this.content = content;
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}
