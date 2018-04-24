package aspectos;

public aspect Excepciones {
	pointcut excepcionSQL() : handler(SQLException);
	
	before() : excepcionSQL() {
		System.out.println("Excepci�n SQL controlada mediante aspectos");
	}
}
