using System;
using System.Collections.Generic;
using System.Linq;

public class Note
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Tags { get; set; }
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; }

    public Note(string title, string content, string tags, int priority)
    {
        Title = title;
        Content = content;
        Tags = tags;
        Priority = priority;
        CreatedAt = DateTime.Now;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine($"Tags: {Tags}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine($"Created at: {CreatedAt}");
    }
}

public class NoteOrganizer
{
    private List<Note> notes = new List<Note>();

    public void AddNote()
    {
        Console.WriteLine("Enter title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter content:");
        string content = Console.ReadLine();

        Console.WriteLine("Enter tags (separate by commas):");
        string tags = Console.ReadLine();

        Console.WriteLine("Enter Priority (1 = High, 2 = Medium, 3 = Low):");
        int priority;
        while (!int.TryParse(Console.ReadLine(), out priority) || priority < 1 || priority > 3)
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        }

        Note note = new Note(title, content, tags, priority);
        notes.Add(note);
        Console.WriteLine("Note added successfully!");
    }

    public void ViewNotes()
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("No notes available.");
            return;
        }

        foreach (var note in notes)
        {
            note.Display();
        }
    }

    public void SearchNotes()
    {
        Console.WriteLine("Enter keyword to search by title or tags:");
        string keyword = Console.ReadLine();

        var searchResults = notes.Where(n =>
            n.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            n.Tags.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        );

        if (!searchResults.Any())
        {
            Console.WriteLine("No notes found with that keyword.");
            return;
        }

        foreach (var note in searchResults)
        {
            note.Display();
        }
    }

    public void DeleteNote()
    {
        Console.WriteLine("Enter the title of the note to delete:");
        string title = Console.ReadLine();

        Note noteToRemove = notes.FirstOrDefault(n => n.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (noteToRemove != null)
        {
            notes.Remove(noteToRemove);
            Console.WriteLine("Note deleted successfully.");
        }
        else
        {
            Console.WriteLine("Note not found.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NoteOrganizer organizer = new NoteOrganizer();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nSmart Notes Organizer");
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. View Notes");
            Console.WriteLine("3. Search Notes");
            Console.WriteLine("4. Delete Note");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    organizer.AddNote();
                    break;

                case "2":
                    organizer.ViewNotes();
                    break;

                case "3":
                    organizer.SearchNotes();
                    break;

                case "4":
                    organizer.DeleteNote();
                    break;

                case "5":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using Smart Notes Organizer!");
    }
}