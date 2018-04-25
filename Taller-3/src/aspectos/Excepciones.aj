package aspectos;

import java.sql.SQLException;

public aspect Excepciones {
	pointcut excepcionSQL() : handler(SQLException);
	
	before() : excepcionSQL() {
		System.out.println("Excepción SQL controlada mediante aspectos");
	}
}
