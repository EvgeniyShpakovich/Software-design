using System;
using System.Collections.Generic;

public class TextDocument
{
    public string Text { get; set; }

    public TextDocument(string text)
    {
        Text = text;
    }

    public void Edit(string newText)
    {
        Text = newText;
    }

    public TextDocumentMemento SaveState()
    {
        return new TextDocumentMemento(Text);
    }

    public void RestoreState(TextDocumentMemento memento)
    {
        Text = memento.GetText();
    }
}

public class TextDocumentMemento
{
    private readonly string _text;

    public TextDocumentMemento(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }
}

public class TextEditor
{
    private TextDocument _document;
    private Stack<TextDocumentMemento> _history = new Stack<TextDocumentMemento>();

    public TextEditor(TextDocument document)
    {
        _document = document;
    }

    public void EditDocument(string newText)
    {
        _history.Push(_document.SaveState());
        _document.Edit(newText);
        Console.WriteLine($"Документ змінено: {_document.Text}");
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            TextDocumentMemento previousState = _history.Pop();
            _document.RestoreState(previousState);
            Console.WriteLine($"Операція скасована: {_document.Text}");
        }
        else
        {
            Console.WriteLine("Немає змін для скасування.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        TextDocument document = new TextDocument("Початковий текст");
        TextEditor editor = new TextEditor(document);

        Console.WriteLine($"Початковий стан документа: {document.Text}");

        editor.EditDocument("Змінений текст 1");
        editor.EditDocument("Змінений текст 2");

        editor.Undo();
        editor.Undo();
        editor.Undo();
    }
}
