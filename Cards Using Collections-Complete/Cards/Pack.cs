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

        
        
        //PACK���캯��  �Ƚ���һ��hashtable ���ϣ� cardPack key = clubs�� value=  ��SortedList type   key =two  value =  PlayingCard(suit, value)��
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
          
            //���Ƴ����õ�����ٷ����С�
            //������һ�������������һ�� NumSuit 4���ڵ�������� �ٽ���������Ϊ Suit ���ͣ�
            // ��󽫴�Suit �����ݵ�IsSuitEmpty�����С� ��IsSuitEmpty������two-Ace
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

            //����2��ǳ���Ҫ��  ��HASHTABLE ��CardPack ��suit key ��ȡ���õ�һ��value������value����ΪSortedlist��
            
            SortedList cardsInSuit = (SortedList)cardPack[suit];

            //��SortedList ��CardsInsuit �� vlaue key ����ȡ�����õ�һ��Value  ֵΪPlayingCard ����  ����Ϊһ��PlayingCard(suit, value) ����
            PlayingCard card = (PlayingCard)cardsInSuit[value];
            cardsInSuit.Remove(value);
            return card; 
        }

        private bool IsSuitEmpty(Suit suit)
        {

            //��IsSuitEmpty������two-Ace����Suit��Value���ݳ�ȥ�����ж��Ƿ�����δ��
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
           //�������Suit��Value
            // �������Hashtable�еĶ����أ� ��Hashtable[key]�õ�Valueֵ����ֵΪһ�����󣬷����һ��SortedList���͸�SortedList����
            
            SortedList cardsInSuit = (SortedList)this.cardPack[suit];

            // ����SortedList.ContainsKey�������ж��Ƿ���ڶ�Ӧ��keyֵ��
            return (!cardsInSuit.ContainsKey(value)); 
        }
	}
}