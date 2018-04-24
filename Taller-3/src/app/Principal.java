package app;

import java.sql.SQLException;
import java.util.List;
import org.pl.eshop.dto.*;

public class Principal {

	public static void main(String[] args) {
		try {
			CategoriaDAO catDao = new CategoriaDAOMySQL();			
			
			// Agregar categoria
			Categoria nuevaCategoria = new Categoria(1, "Ropa Masculina", "Ropa para hombres, de la mejor calidad");
			catDao.agregar(nuevaCategoria);
			
			// Obtener todas las categorias
			List<Categoria> categorias = catDao.obtenerTodas();
			
			// Obtener categoria por id
			Categoria categoriasID = catDao.obtenerPorId(categorias.get(0).getId());
			
			// Modificar categoria			
			Categoria modificarCategoria = new Categoria(categorias.get(0).getId(), "Ropa Masculina", "Modificación Ropa para hombres, de la mejor calidad");
			catDao.modificar(modificarCategoria);
			
			// Eliminar categoria
			catDao.eliminar(categorias.get(0));
			
			catDao = null;
			
		} catch (SQLException e) {
			System.out.println("Hay problema para acceder a la base de datos: " + e.getMessage());
		} catch (Exception e) {
			System.out.println("Se ha presentado una excepción no controlada");
		}		
	}

}