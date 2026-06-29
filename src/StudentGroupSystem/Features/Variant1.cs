using System.Collections.Generic;

namespace StudentGroupSystem.Features
{
    public class NotesEditor
    {
        private Stack<string> UndoStack = new Stack<string>();
        private Stack<string> RedoStack = new Stack<string>();

        public string CurrentText { get; private set; } = "";

        public void Add(string text)
        {
            UndoStack.Push(CurrentText);
            CurrentText += text;
            RedoStack.Clear();
        }

        public void Undo()
        {
            if (UndoStack.Count == 0)
                return;

            RedoStack.Push(CurrentText);
            CurrentText = UndoStack.Pop();
        }

        public void Redo()
        {
            if (RedoStack.Count == 0)
                return;

            UndoStack.Push(CurrentText);
            CurrentText = RedoStack.Pop();
        }
    }
}
