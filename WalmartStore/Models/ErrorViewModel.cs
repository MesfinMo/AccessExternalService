using System;

namespace WalmartStore.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorMessage { get; set; }
        public ErrorLevel ErrorLevel { get; set; }
    }

    public enum ErrorLevel
    {
        Info = 0,
        Warning = 1,
        Serious = 2

    }
}