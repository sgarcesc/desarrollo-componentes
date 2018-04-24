package aspectos;

public aspect Excepciones {
	pointcut excepcion() : handler(dominio.DimensionNegativaException);
	
	//advice
	before() : excepcion(){
		System.out.println("Se comienza el tratamiento de la excepción.");
	}
}
