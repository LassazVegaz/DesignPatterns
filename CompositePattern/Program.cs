using CompositePattern;
using CompositePattern.Shapes;

var square1 = new Square { SideLength = 5 };
var square2 = new Square { SideLength = 12 };
var square3 = new Square { SideLength = 32 };

var ciecle1 = new Circle { Radius = 14 };
var ciecle2 = new Circle { Radius = 7 };
var ciecle3 = new Circle { Radius = 14 };
var ciecle4 = new Circle { Radius = 17 };

var gallery1 = new Gallery(square1, ciecle1, ciecle2);
var gallery2 = new Gallery(square2, square3);
var gallery3 = new Gallery(ciecle3);
var gallery4 = new Gallery();

var mainGallery = new Gallery(gallery1, gallery2, gallery3, gallery4, ciecle4);

Main.Run(mainGallery);