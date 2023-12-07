using System.Diagnostics.Tracing;

var todos = new List<string>();
bool appWorking = true;
do
{
    Console.Clear();
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    Console.WriteLine("\nWhat do you want to do?");
    bool isChar = char.TryParse(Console.ReadLine(), out char userChoice);
    if (!isChar)
    {
        Console.WriteLine("Invalid input");
        Console.ReadKey();
        continue;
    }
    switch (userChoice)
    {
        case 's':
        case 'S':
            PrintTodos(todos);
            break;
        case 'a':
        case 'A':
            AddTodo(todos);
            break;
        case 'r':
        case 'R':
            RemoveTodo(todos);
            break;
        case 'e':
        case 'E':
            appWorking = false;
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
    Console.ReadKey();
} while (appWorking);

void PrintTodos(List<string> todos)
{
    Console.Clear();
    if (todos.Count == 0)
    {
        ShowNoToDosMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}
void AddTodo(List<string> todos)
{
    Console.Clear();
    string todo;
    do
    {
        Console.WriteLine("Enter the TODO: ");
        todo = Console.ReadLine();

    } while (!IsToDoValid(todo));

    todos.Add(todo);
    Console.WriteLine($"TODO successfully added: {todo}");
}

bool IsToDoValid(string todo)
{
    if (todos.Contains(todo))
    {
        Console.WriteLine("TODO like that alredy exists");
        return false;
    }
    else if (todo == "")
    {
        Console.WriteLine("TODO can't be empty");
        return false;
    }
    return true;
}
void RemoveTodo(List<string> todos)
{
    Console.Clear();

    if (todos.Count == 0)
    {
        ShowNoToDosMessage();
        return;
    }

    int index;
    do
    {
        PrintTodos(todos);
        Console.WriteLine("Select the index of the TODO you want to remove:");
    } while (!TryReadIndex(out index));

    RemoveToDoAtIndex(todos, index);
}

bool TryReadIndex(out int index)
{
    var input = Console.ReadLine();
    if (input == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    else if (int.TryParse(input, out index) && 
        index <= todos.Count &&
        index >= 1)
    {
        return true;
    }
        Console.WriteLine("The Given index is not valid");
    return false;
}
static void ShowNoToDosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}

static void RemoveToDoAtIndex(List<string> todos, int index)
{
    Console.WriteLine($"TODO removed: {todos.ElementAt(index - 1)}");
    todos.RemoveAt(index - 1);
}