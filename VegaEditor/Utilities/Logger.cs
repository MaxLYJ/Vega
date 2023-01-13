using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace VegaEditor.Utilities
{
    enum MessageType
    {
        Info = 0x01,
        Warning = 0x02,
        Error = 0x04
    }

    class LogMessage
    {
        public DateTime Time { get; }
        public MessageType MessageType { get; }
        public string Message { get; }
        public string FileName { get; }
        public string CallerName { get; }
        public int Line { get; }
        public string MetaData => $@"{FileName}: {CallerName} ({Line})";

        public LogMessage(MessageType messageType, string message, string filePath, string callerName, int line)
        {
            Time = DateTime.Now;
            Message = message;
            MessageType = messageType;
            FileName = Path.GetFileName(filePath);
            CallerName = callerName;
            Line = line;
        }
    }

    static class Logger
    {
        private static int _messageFilter = (int)(MessageType.Info | MessageType.Warning | MessageType.Error);
        private readonly static ObservableCollection<LogMessage> _messages = new ObservableCollection<LogMessage>();
        public static ReadOnlyObservableCollection<LogMessage> Messages { get; } = new ReadOnlyObservableCollection<LogMessage>(_messages);
        public static CollectionViewSource FilteredMessages { get; } = new CollectionViewSource() { Source = Messages };

        public static async void Log(MessageType messageType, string msg,
            [CallerFilePath] string filePath = "", [CallerMemberName] string callerName = "",
            [CallerLineNumber] int line = 0)
        {
            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _messages.Add(new LogMessage(messageType, msg, filePath, callerName, line));
            }));
        }

        public static async void Clear()
        {
            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _messages.Clear();
            }));
        }

        public static void SetFilterMask(int maskFilter)
        {
            _messageFilter = maskFilter;
            FilteredMessages.View.Refresh();
        }

        static Logger()
        {
            FilteredMessages.Filter += (s, e) =>
            {
                var type = (int)(e.Item as LogMessage).MessageType;
                e.Accepted = (type & _messageFilter) != 0;
            };
        }
    }
}
