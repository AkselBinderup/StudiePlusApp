using ReactiveUI;
using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class MessagesPageViewModel : ViewModelBase
{
    public ObservableCollection<ConversationModel> Conversations { get; } = new();
    private ConversationModel _selectedConversation;
    public ConversationModel SelectedConversation
    {
        get => _selectedConversation;
        set => this.RaiseAndSetIfChanged(ref _selectedConversation, value);
    }

    private string _replyText;
    public string ReplyText
    {
        get => _replyText;
        set => this.RaiseAndSetIfChanged(ref _replyText, value);
    }

    public ReactiveCommand<Unit, Unit> SendReplyCommand { get; }
    public ReactiveCommand<Unit, Unit> StartNewConversationCommand { get; }

    public bool CanReply => SelectedConversation != null && !string.IsNullOrWhiteSpace(ReplyText);

    public MessagesPageViewModel()
    {
        // Dummy data
        Conversations.Add(new ConversationModel
        {
            Title = "Matematik opgave 5",
            Participants = new[] { "Lærer Mads", "Dig" },
            Messages = new ObservableCollection<MessageModel>
            {
                new MessageModel { Sender = "Lærer Mads", Content = "Har du spørgsmål til opgaven?", SentTime = DateTime.Now.AddMinutes(-30) },
                new MessageModel { Sender = "Dig", Content = "Ja, hvordan løser man del b?", SentTime = DateTime.Now.AddMinutes(-10) }
            }
        });

        Conversations.Add(new ConversationModel
        {
            Title = "Gruppeprojekt i historie",
            Participants = new[] { "Jonas", "Emma", "Dig" },
            Messages = new ObservableCollection<MessageModel>
            {
                new MessageModel { Sender = "Emma", Content = "Hvornår mødes vi til gruppearbejde?", SentTime = DateTime.Now.AddHours(-1) }
            }
        });

        SendReplyCommand = ReactiveCommand.Create(SendReply, this.WhenAnyValue(x => x.CanReply));
        StartNewConversationCommand = ReactiveCommand.Create(StartNewConversation);
    }

    private void SendReply()
    {
        if (!CanReply) return;

        SelectedConversation.Messages.Add(new MessageModel
        {
            Sender = "Dig",
            Content = ReplyText,
            SentTime = DateTime.Now
        });

        ReplyText = string.Empty;
    }

    private void StartNewConversation()
    {
        // Placeholder – in production, show a dialog or navigate to a "new message" page
        Conversations.Add(new ConversationModel
        {
            Title = "Ny samtale",
            Participants = new[] { "Dig", "Modtager" },
            Messages = new ObservableCollection<MessageModel>
            {
                new MessageModel { Sender = "Dig", Content = "Hej, hvad vil du snakke om?", SentTime = DateTime.Now }
            }
        });

        SelectedConversation = Conversations.Last();
    }
}

public class ConversationModel
{
    public string Title { get; set; }
    public string[] Participants { get; set; }
    public ObservableCollection<MessageModel> Messages { get; set; } = new();

    public string LastMessagePreview =>
        Messages.LastOrDefault()?.Content.Length > 30
        ? Messages.LastOrDefault()?.Content.Substring(0, 30) + "..."
        : Messages.LastOrDefault()?.Content;
}

public class MessageModel
{
    public string Sender { get; set; }
    public string Content { get; set; }
    public DateTime SentTime { get; set; }
}