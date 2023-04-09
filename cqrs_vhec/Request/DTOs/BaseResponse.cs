namespace cqrs_vhec.Request.DTOs
{
    public class BaseResponse<T>
    {
        public bool _success { get; set; } = false;
        public string _message { get; set; } = "";
        public T _data { get; set; }

        public BaseResponse() { }

        public BaseResponse(bool success, string message, T data) 
        { 
            this._success = success;
            this._message = message;
            this._data = data;
        }
    }
}
