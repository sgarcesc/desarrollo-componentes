package aspectos;

public aspect Logging {
	pointcut llamada() : call(double *.area()) || call(double *.perimetro());
	
	//advice
	before() : llamada(){
		System.out.println("Se llamó el método área o perímetro.");
	}
}
