#include <opencv2/opencv.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>

using namespace cv;

int main()
{
	//Mat srcimg = imread("board.jpg");
	Mat srcimg = imread("./circletest-emgv/5x5circle-bw.bmp");

	imshow("Origin Picture",srcimg);

	Mat dstimage, edge, grayImage;

	dstimage.create(srcimg.size(),srcimg.type());

	cvtColor(srcimg,grayImage,CV_BGR2GRAY);

	blur(grayImage,edge,Size(1,1));
	.
	Canny(edge,edge,3,9,3);

	imshow("Canny Edge Picture", edge);

	// Mat element = getStructuringElement(MORPH_RECT,Size(3,3));

	// Mat dstimg;
	// erode(srcimg,dstimg,element);

	//imshow("Erode Picture", dstimg);

	waitKey(0);
	return 0;
}
