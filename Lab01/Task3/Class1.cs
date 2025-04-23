using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

// 3.
//class Rectangle
// def initialize(width, height)
// @width, @height = width, height
// end
// def set_width(width)
// @width = width
// end
// def set_height(height)
// @height = height
// end
//end
//class Square<Rectangle "inherits"
// def set_width(width)
// super(width)
// @height = height
// end
// def set_height(height)
// super(height)
// @width = width
// end
//end

//this violates the LSP as square not substituable for rectangle 

class Rectangle
{
	double width;
	double height;
	Rectangle(double _width, double _height)
	{
		this.width = _width;
		this.height = _height;
	}

}
class Square
{
	double sideLength;
	Square(double _sideLength)
	{
		this.sideLength = _sideLength;
	}
}

