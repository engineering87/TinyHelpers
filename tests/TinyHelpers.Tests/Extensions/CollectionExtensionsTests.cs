﻿using TinyHelpers.Extensions;

namespace TinyHelpers.Tests.Extensions;

public class CollectionExtensionsTests
{

    [Fact]
    public void Chunk_ExactMultipleChunkSize_ReturnsEqualChunks()
    {
        // Arrange
        var source = Enumerable.Range(1, 6);
        var chunkSize = 3;

        // Act
        var result = source.Chunk(chunkSize).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1, 2, 3 }, result[0]);
        Assert.Equal(new[] { 4, 5, 6 }, result[1]);
    }

    [Fact]
    public void Chunk_ChunkSizeNotDivisible_ReturnsLastChunkSmaller()
    {
        // Arrange
        var source = Enumerable.Range(1, 7);
        var chunkSize = 3;

        // Act
        var result = source.Chunk(chunkSize).ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { 1, 2, 3 }, result[0]);
        Assert.Equal(new[] { 4, 5, 6 }, result[1]);
        Assert.Equal(new[] { 7 }, result[2]);
    }

    [Fact]
    public void GetLongCount_PredicateAlwaysTrue_ReturnsTotalCount()
    {
        // Arrange
        var source = Enumerable.Range(1, 10);

        // Act
        var result = source.GetLongCount(x => true);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void GetLongCount_PredicateAlwaysFalse_ReturnsZero()
    {
        // Arrange
        var source = Enumerable.Range(1, 10);

        // Act
        var result = source.GetLongCount(x => x > 10);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Remove_MatchingElements_RemovesCorrectElements()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        collection.Remove(x => x % 2 == 0);

        // Assert
        Assert.Equal(new[] { 1, 3, 5 }, collection);
    }

    [Fact]
    public void PerformAction_ForEach_ReturnDesiredResult()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        var modifiedList = new List<int>();  // Local variable for storing result

        // Act
        collection.ForEach(x => modifiedList.Add(x * 5));

        // Assert
        Assert.Equal(new[] { 5, 10, 15, 20, 25 }, modifiedList);
    }

    [Fact]
    public void List_IsEmpty_ReturnTrue()
    {
        var collection = new List<int>();

        Assert.True(collection.IsEmpty());
    }
}
