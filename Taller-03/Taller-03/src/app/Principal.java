package app;

import java.sql.SQLException;
import java.util.List;
import dominio.*;

public class Principal {

	public static void main(String[] args) {
		try {
			CategoriaDAO catDao = new CategoriaDAOMySQL();
			List<Categoria> categorias = catDao.obtenerTodas();
			
			Categoria nuevaCategoria = new Categoria(1, "Ropa Masculina", "Ropa para hombres, de la mejor calidad");
			catDao.agregar(nuevaCategoria);
			
		} catch (SQLException e) {
			System.out.println("Hay problema para acceder a la base de datos: " + e.getMessage());
		} catch (Exception e) {
			System.out.println("Se ha presentado una excepción no controlada");
		}		
	}

}
