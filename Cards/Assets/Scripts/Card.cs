using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
   public enum Suit
    {
        Invalid=-1,
        Club,
        Dia,
        Heart,
        Spade,
        Max
    };

    public Suit CardSuit = Suit.Invalid;

    public int Number = 0;

    public int Num = 0;

    public const int CardMax = 52;

    public Card(Suit suit,int number,int num)
    {
        CardSuit = suit;
        Number = number;
        Num = num;
    }
    ///<summary>
    ///カードの数を決める1"13
    ///</summary>
    ///<returns></returns>
    public static int CardNumJudge(int _num)
    {
        for(int i=0;i<13;i++)
        {
            if(_num%13==i)
            {
                return i + 1;
            }
        }
        return 0;
    }

    ///<summary>
    ///カードの役を決める0～3
    ///</summary>
    ///<returns></returns>
    public static Suit CardSuitJudge(int _num)
    {
        for(int i=0;i<(int)Suit.Max;i++)
        {
            if(_num/13==i)
            {
                return (Suit)i;
            }
        }
        return Suit.Invalid;
    }
}
