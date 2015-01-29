namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private Hashtable cardPack;
        //private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();

        
        
        //PACK构造函数  先建立一个hashtable 集合， cardPack key = clubs， value=  （SortedList type   key =two  value =  PlayingCard(suit, value)）
        //
        
        public Pack()
		{
            cardPack = new Hashtable();
            //this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];

            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                SortedList cardingroup=new SortedList();
               // SortedList cardsInSuit = new SortedList();
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    cardingroup.Add(value, new PlayingCard(suit, value));
                    //cardsInSuit.Add(value, new PlayingCard(suit, value)); 
                    //this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
               
                this.cardPack.Add(suit,cardingroup);
                // this.cardPack.Add(suit, cardsInSuit);
            }
		}

        public PlayingCard DealCardFromPack()
        {
          
            //发牌程序用的是穷举法进行。
            //首先用一个随机函数生成一个 NumSuit 4以内的随机数， 再将此数封箱为 Suit 类型，
            // 随后将此Suit 数传递到IsSuitEmpty方法中。 在IsSuitEmpty将遍历two-Ace
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            //以下2句非常重要。  将HASHTABLE 类CardPack 的suit key 项取出得到一个value，将此value封箱为Sortedlist类
            
            SortedList cardsInSuit = (SortedList)cardPack[suit];

            //将SortedList 类CardsInsuit 的 vlaue key 项再取出，得到一个Value  值为PlayingCard 对象  封箱为一个PlayingCard(suit, value) 对象
            PlayingCard card = (PlayingCard)cardsInSuit[value];
            cardsInSuit.Remove(value);
            return card; 
        }

        private bool IsSuitEmpty(Suit suit)
        {

            //在IsSuitEmpty将遍历two-Ace，将Suit和Value传递出去进行判断是否还有牌未发
            bool result = true;

            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
           //将传入的Suit和Value
            // 如何引用Hashtable中的对象呢？ 用Hashtable[key]得到Value值，该值为一个对象，封箱成一个SortedList类型给SortedList对象。
            
            SortedList cardsInSuit = (SortedList)this.cardPack[suit];

            // 调用SortedList.ContainsKey方法来判定是否存在对应的key值。
            return (!cardsInSuit.ContainsKey(value)); 
        }
	}
}