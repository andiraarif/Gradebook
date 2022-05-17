using System;
using System.Collections.Generic;
using Xunit;

namespace Gradebook.Tests;

public class BookTests
{
    [Fact]
    public void AddGradeTest()
    {
        // arrange
        var grades = new List<double> {0, 100, -50, 150};
    
        var book = new InMemoryBook("Test Book");

        // act
        book.AddGrade(grades[0]);
        book.AddGrade(grades[1]);

        // assert
        Assert.Equal(grades[0], book.GetGrades()[0]);
        Assert.Equal(grades[1], book.GetGrades()[1]);
        Assert.Throws<System.IO.InvalidDataException>(() => book.AddGrade(grades[2]));
        Assert.Throws<System.IO.InvalidDataException>(() => book.AddGrade(grades[3]));
        //Assert.Throws<System.IO.InvalidDataException>(() => book.AddGrade(" "));
    }

    [Fact]
    public void GetGradesTest()
    {
        // arrange
        var grades = new List<double> {0, 20, 40, 60, 80, 100};
        var book = new InMemoryBook("Test Book");

        // act
        foreach (double grade in grades)
        {
            book.AddGrade(grade);
        }

        // assert
        Assert.Equal(grades, book.GetGrades());
    }

    [Fact]
    public void GetStatisticsTest()
    {
        // arrange
        var grades = new List<double> {0, 20, 40, 60, 80, 100};
        var book = new InMemoryBook("Test Book");

        // act
        foreach (double grade in grades)
        {
            book.AddGrade(grade);
        }

        // assert
        Assert.Equal(0, book.GetStatistics().Lowest);
        Assert.Equal(100, book.GetStatistics().Highest);
        Assert.Equal(50, book.GetStatistics().Average);
        Assert.Equal('E', book.GetStatistics().AverageInLetter);
    }
}