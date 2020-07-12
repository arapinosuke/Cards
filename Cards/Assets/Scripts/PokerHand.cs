using System.Collections.Generic;
using System.Linq;

public class PokerHand
{
   public enum Hand
   {
        None=-1,       //無し
        OnePair,　　　 //ワンペア
        TwoPair,       //ツーペア
        ThreeOhKind,   //スリーカード
        Straight,      //ストレート
        Flush,　       //フラッシュ
        FullHouse,     //フルハウス
        FourOhKind,　　//フォーカード
        StraightFlush, //ストレートフラッシュ　
        RoyalFlush　　 //ロイヤルストレートフラッシュ
   }

    public static Hand CardHand(List<Card>cards)
    {
        //まず数字をソートします(1,2,3,4等)
        cards.Sort((a, b) => a.Number - b.Number);

        var kinds = 0;
        var cardsElement = 0;

        foreach(var card in cards.ToLookup(s=>s.Number))
        {
            if(card.Count()>1)
            {
                cardsElement++;
                kinds += card.Count();
            }
        }
        //フラッシュの確認Suitがすべて同じか
        var clubRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Club);
        var diaRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Dia);
        var heartRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Heart);
        var spareRoyal= cards.TrueForAll(s => s.CardSuit == Card.Suit.Spade);

        var firstCardNo = cards[0].Number;

        #region ロイヤルストレートフラッシュ(1,10,11,12,13)Suitが全て一緒
        if(firstCardNo.Equals(1))
        {
            if(cards[1].Number.Equals(10))
            {
                var count = 0;
                for(int i=2;i<cards.Count;i++)
                {
                    if (cards[i].Number.Equals(9+i))
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                //Straightは確定
                if(count.Equals(3))
                {
                    if(clubRoyal || diaRoyal || heartRoyal || spareRoyal)
                    {
                        return Hand.RoyalFlush;
                    }
                    else
                    {
                        return Hand.Straight;
                    }
                }
            }
        }
        #endregion

        #region ストレートフラッシュ
        var straightCount = 0;
        for(int i=1;i<cards.Count;i++)
        {
            var straightCardNo = firstCardNo;
            if(cards[i].Number.Equals(straightCardNo+i))
            {
                straightCount++;
                continue;
            }
            else
            {
                break;
            }
        }
        if(straightCount.Equals(4))
        {

            //上のboolのいずれかがtrueだった場合はStaraightFlush
            if(clubRoyal || diaRoyal || heartRoyal || spareRoyal)
            {
                return Hand.StraightFlush;
            }
            else
            {
                return Hand.Straight;
            }
        }
　　　　#endregion

        #region フォーカード

        if(cardsElement.Equals(1)&&kinds.Equals(4))
        {
            return Hand.FourOhKind;
        }
        #endregion

        #region フルハウス

        if(cardsElement.Equals(2)&&kinds.Equals(5))
        {
            return Hand.FullHouse;
        }

　　　　#endregion

        #region フラッシュ
        if(clubRoyal || diaRoyal || heartRoyal || spareRoyal)
        {
            return Hand.Flush;
        }
　　　　#endregion

　　　　#region ワンペアかツーペアかスリーカード

        if(kinds.Equals(3))
        {
            return Hand.ThreeOhKind;
        }


        if(cardsElement.Equals(2)&&kinds.Equals(4))
        {
            return Hand.TwoPair;
        }
        if(kinds.Equals(2))
        {
            return Hand.OnePair;
        }
        #endregion

        return Hand.None;
    }
}
