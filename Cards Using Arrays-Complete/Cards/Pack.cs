namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;//扑克牌中的四种花色
        public const int CardsPerSuit = 13;//扑克牌的13种面值
        private PlayingCard[,] cardPack;//存储扑克牌对象的数组
        private Random randomCardSelector = new Random();//用来生成随机数，目的是随机发牌

        //构造方法用来初始化扑克牌数组。
		public Pack()
		{
            //生成扑克牌数组的实例
            cardPack = new PlayingCard[NumSuits,CardsPerSuit];
            //将扑克牌数组中的每个元素都实例化成一个扑克牌的对象
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
		}

        //发牌程序
        public PlayingCard DealCardFromPack()
        {
            //随机生成一种花色
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            //判断该随机花色是否全部发完牌。
            while (this.IsSuitEmpty(suit))
            {
                //重新随机生成一个花色
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }
            //随机产生一个牌面值
            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            //随机产生一张扑克牌，这张牌在数组里面的值不为空的
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            PlayingCard card = this.cardPack[(int)suit, (int)value];
            this.cardPack[(int)suit, (int)value] = null;
            return card; 
        }
        

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;

            //判断具有suit花色的每张牌(2~A),如果有一张牌不是null的result值为false，否则为true
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

        //如果这个数组中的元素值为null则代表该牌已经发出
        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            return (this.cardPack[(int)suit, (int)value] == null);
        }
	}
}