using Xamarin.Forms;

namespace PasswordReminder.Model
{
  public    class ResultModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public T Value { get; set; }
    }
}
