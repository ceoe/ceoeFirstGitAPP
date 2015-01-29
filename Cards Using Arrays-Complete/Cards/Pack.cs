namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;//�˿����е����ֻ�ɫ
        public const int CardsPerSuit = 13;//�˿��Ƶ�13����ֵ
        private PlayingCard[,] cardPack;//�洢�˿��ƶ��������
        private Random randomCardSelector = new Random();//���������������Ŀ�����������

        //���췽��������ʼ���˿������顣
		public Pack()
		{
            //�����˿��������ʵ��
            cardPack = new PlayingCard[NumSuits,CardsPerSuit];
            //���˿��������е�ÿ��Ԫ�ض�ʵ������һ���˿��ƵĶ���
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
		}

        //���Ƴ���
        public PlayingCard DealCardFromPack()
        {
            //�������һ�ֻ�ɫ
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            //�жϸ������ɫ�Ƿ�ȫ�������ơ�
            while (this.IsSuitEmpty(suit))
            {
                //�����������һ����ɫ
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }
            //�������һ������ֵ
            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            //�������һ���˿��ƣ������������������ֵ��Ϊ�յ�
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

            //�жϾ���suit��ɫ��ÿ����(2~A),�����һ���Ʋ���null��resultֵΪfalse������Ϊtrue
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

        //�����������е�Ԫ��ֵΪnull���������Ѿ�����
        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            return (this.cardPack[(int)suit, (int)value] == null);
        }
	}
}