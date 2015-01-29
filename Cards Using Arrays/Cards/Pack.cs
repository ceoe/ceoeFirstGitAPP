namespace Cards
{
    using System;
    using System.Collections;

    class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        //����һ��PlayCard�Ķ�ά������� cardPack,����������������������ǲ�δ������ĵĶ��󸳳�ֵ��
        //Ĭ������£�δ��ֵ������£�����Ϊnull��
        private PlayingCard[,] cardPack= new PlayingCard[NumSuits, CardsPerSuit];
        private Random randomCardSelector = new Random();

        public Pack()
        {
            // to do - initialize the pack of cards

           //������췽��������ʼ���˿������顣

            //cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            // ��cardPack������󸳳�ֵ ��Suit ���ֻ�ɫΪ�У�2-AΪ�У�
            //���cardPack[4,13] 4�� 13�� palyingCard�Ķ������
            //�������е�ÿ��Ԫ�ض�ʵ������ 
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }


        }

        public PlayingCard DealCardFromPack()
        {
            //// to do - pick a random card, remove it from the pack, and return it
            //throw new NotImplementedException("DealCardFromPack - TBD");
            Suit suit = (Suit) randomCardSelector.Next(NumSuits);

            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            Value value = (Value) randomCardSelector.Next(CardsPerSuit);

            while (this.IsCardAlreadyDealt(suit,value))
            {
                 value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            PlayingCard card = this.cardPack[(int)suit,(int)value];

            this.cardPack[(int) suit, (int) value] = null;
            return card;

        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;

            //for (Value value  = Value.Two; value <= Value.Ace; value++)
            for (Value value = Value.Two; value<= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }
            // to do - return true if there are no more cards available in this suit
           //  throw new NotImplementedException("IsSuitEmpty - TBD");
            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            // to do - return true if this card has already been dealt   
           
            //throw new NotImplementedException("IsCardAlreadyDealt - TBD");
            bool result = false;
            result = this.cardPack[(int)suit,(int)value] == null;
            return result;

        }

    }
}