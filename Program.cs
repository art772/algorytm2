using System.Collections.Generic;

//List<(int, int)> lessonList = new List<(int, int)>() { (30, 75), (0, 50), (60, 150) };  //  2
//List<(int, int)> lessonList = new List<(int, int)>() { (0, 75), (0, 35), (40, 90), (20, 70) };    //  3
//List<(int, int)> lessonList = new List<(int, int)>() { (0, 40), (0, 20), (20, 40), (20, 60), (30, 60), (30, 50), (40, 100) }; //  4
//List<(int, int)> lessonList = new List<(int, int)>() { (0, 40), (0, 20), (20, 30), (20, 60), (30, 60) };  //  3 
//List<(int, int)> lessonList = new List<(int, int)>() { (0, 40), (0, 20), (20, 30), (20, 60), (30, 60), (80, 100) };  //  3
List<(int, int)> lessonList = new List<(int, int)>() { (0, 20), (30, 50), (60, 70), (80, 100) };  //  1

List<(int, int)> classList = new List<(int, int)>();

lessonList.Sort();

int startLesson;
int stopLesson;
int classCount = 0;

int i = 0;

while (i < lessonList.Count)
{
    startLesson = lessonList[i].Item1;
    stopLesson = lessonList[i].Item2;

    if (i == 0)
    {
        classList.Add((startLesson, stopLesson));
        
        classCount++;
    }
    else
    {
        /*
         * Sprawdzanie czy jakaś lekcja się skończyła.
         * Czas rozpęcięcia kolejnej lekcji to aktualna godzina
         * Jeżeli czas zakończenia jakiejś lekcji jest równy rozpoczęciu innej to usuń lekcję z listy klass
         */
        foreach (var c in classList.ToList())
        {
            if (startLesson == c.Item2)
            {
                classList.Remove((c.Item1, c.Item2));
                classCount--;
            }
        }

        foreach (var c in classList.ToList())
        {
            if (startLesson <= c.Item2)
            {
                classList.Add((startLesson, stopLesson));
                classCount++;
                break;
            }
            else
            {
                break;
            }
        }
    }
    i++;
}
Console.WriteLine(classCount);
