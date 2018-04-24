package aspectos;

public aspect Autorizacion {
	String mensajeAutorizacion = "Simulando una autorización antes de cada método.";
	
	pointcut metodo() : execution(double *.*());
	
	//advice
	before() : metodo(){
		System.out.println(mensajeAutorizacion);
	}
}
