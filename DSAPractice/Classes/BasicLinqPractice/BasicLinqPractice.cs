namespace collections_and_data_iteration_fundamentals;

public class BasicLinqPractice
{
    /*
     *  CATEGORY	     METHODS TO LEARN	                DESCRIPTION
        Filtering	     Where(predicate)	                Filters based on a condition
        Transforming	 Select(selector)	                Projects each element into a new form
        Sorting	         OrderBy, OrderByDescending	        Sorts elements
        Retrieving	     FirstOrDefault, SingleOrDefault	Retrieves a single element safely
        Existence Check	 Any, All	                        Checks if any/all elements meet a condition
        Conversion	     ToList()	                        Converts the result to a list
        Aggregation      Sum, Average, Count, Min, Max      -
     */
    
    /*
     *  1. Get Names of All Enrolled Students
        Return a list of names of all students who are currently enrolled.
        
        2. Find the Oldest Student
        Return the Student object who has the highest age. If none, return null.
        
        3. Check for Failing GPAs
        Return true if any student has a GPA below 2.0.
        
        4. Count High Achievers
        Return the total number of students with a GPA of 3.5 or above.
        
        5. Are All Students Enrolled?
        Return true if every student in the list is marked as enrolled.
        
        6. Sort Students by GPA (Descending)
        Return the list of students sorted from highest to lowest GPA.
        
        7. Get First Student Under Age 20
        Return the first student who is under 20 years old, or null if none.
        
        8. List of Names for Students with GPA ≥ 3.0
        Return a list of strings with only the names of students who have at least 3.0 GPA.
        
        9. Alphabetical Student Names
        Return a list of student names sorted alphabetically.
        
        10. Convert List to Array
        Take the current student list and convert it into an array.
     */
    
    List<Student> students = new List<Student>
    {
        new Student { Name = "Alice", Age = 19, GPA = 3.8, IsEnrolled = true },
        new Student { Name = "Bob", Age = 22, GPA = 2.5, IsEnrolled = false },
        new Student { Name = "Charlie", Age = 20, GPA = 1.9, IsEnrolled = true },
        new Student { Name = "Diana", Age = 18, GPA = 3.2, IsEnrolled = true },
        new Student { Name = "Evan", Age = 21, GPA = 2.8, IsEnrolled = true },
        new Student { Name = "Fiona", Age = 23, GPA = 3.9, IsEnrolled = false },
        new Student { Name = "George", Age = 17, GPA = 3.0, IsEnrolled = true }
    };

    public List<Student> getEnrolledStudents()
    {
        return students.Where(student => student.IsEnrolled).ToList();
    }

    public Student getOldestStudent()
    {
        return students.OrderByDescending(student => student.Age).FirstOrDefault();
    }

    public bool hasFailingStudents()
    {
        return students.Any(student => student.GPA < 2.0);
    }

    public int getCountOfHighAchievers()
    {
        return students.Count(student => student.GPA >= 3.5);
    }

    public bool areAllStudentsEnrolled()
    {
        return students.All(student => student.IsEnrolled);
    }

    public List<Student> studentsSortedByGradesInDescendingOrder()
    {
        return students.OrderByDescending(student => student.GPA).ToList();
    }

    public Student getFirstStudentUnderAge20()
    {
        return students.FirstOrDefault(student => student.Age < 20);
    }

    public List<string> listOfNamesWithAtLeast3GPA()
    {
        return students.Where(student => student.GPA >= 3.0).Select(student => student.Name).ToList();
    }

    public List<string> listOfStudentNamesSortedAlphabetically()
    {
        return students.Select(student => student.Name).OrderBy(name => name).ToList();
    }

    public Student[] convertStudentListToArray()
    {
        return students.ToArray();
    }
}