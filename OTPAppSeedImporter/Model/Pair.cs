using System;

namespace Model;

/// <summary>
///  Class the repsresents a pair data structure with first and second attributes
/// </summary>
/// <typeparam name="First">First item in pair</typeparam>
/// <typeparam name="Second">Second item in pair</typeparam>
public class Pair<F, S>
{
    public F First;
    public S Second;

    public Pair(F first, S second)
    {
        this.First = first;
        this.Second = second;
    }
}