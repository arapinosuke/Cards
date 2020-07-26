using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    ///<summary>
    ///昇順のDeckをゲットする
    ///</summary>
    public static List<Card> GetDeck()
    {
        var deck = new List<Card>();

        for (int i=0; i<Card.CardMax; i++)
        {
            deck.Add(new Card(Card.CardSuitJudge(i), Card. CardNumJudge(i),i));
        }
        return deck;
    }


    ///<summary>
    ///シャッフルしたDeckをゲットする
    ///</summary>
    public static List<Card> ShuffleDeck(List<Card>deck)
    {
        var shuffleDeck = deck.OrderBy(card => Guid.NewGuid()).ToList();
        return shuffleDeck;
    }

    ///<summary>
    ///カードをDeckの中から取得する
    ///</summary>
    public static Card GetCard(List<Card>deck)
    {
        var card = deck.First();
        deck.RemoveAt(0);
        return card;
    }
}
