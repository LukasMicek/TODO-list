using System.Diagnostics.Tracing;

var todos = new List<string>();
bool appWorking = true;
do
{
    Console.Clear();
    Console.WriteLine("Hello!");
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
            Console.ReadKey();
            break;
        case 'a':
        case 'A':
            AddTodo(todos);
            Console.ReadKey();
            break;
        case 'r':
        case 'R':
            RemoveTodo(todos);
            Console.ReadKey();
            break;
        case 'e':
        case 'E':
            appWorking = false;
            break;
        default:
            Console.WriteLine("Invalid input");
            Console.ReadKey();
            break;
    }
} while (appWorking);

void PrintTodos(List<string> todos)
{
    int i = 1;
    Console.Clear();
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {
        foreach (string todo in todos)
        {
            Console.WriteLine($"{i}. {todo}");
            i++;
        }
    }
}
void AddTodo(List<string> todos)
{
    Console.Clear();
    string todo;
    bool todoExist = false;
    do
    {
        Console.WriteLine("Enter the TODO: ");
        todo = Console.ReadLine();
        if (todos.Contains(todo))
        {
            Console.WriteLine("TODO like that alredy exists");
            break;
        }
        else
        {
                todos.Add(todo);
                Console.WriteLine($"TODO successfully added: {todo}");
                todoExist = true;
        }
    } while (!todoExist);
}
void RemoveTodo(List<string> todos)
{
    Console.Clear();
    string input;
    int index;
    bool todoRemoved = false;
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODO's have been added yet.");
    }
    do
    {
        PrintTodos(todos);
        Console.WriteLine("Select the index of the TODO you want to remove:");
        input = Console.ReadLine();
        bool isIndex = int.TryParse(input, out index);
        if (input == null)
        {
            Console.WriteLine("Selected index cannot be empty.");
        }
        else if (isIndex && index < todos.Count)
        {
            Console.WriteLine($"TODO removed: {todos.ElementAt(index - 1)}");
            todos.RemoveAt(index - 1);
            todoRemoved = true;
        }
        else
        {
            Console.WriteLine("The Given index is not valid");
        }
    } while (!todoRemoved);
}
