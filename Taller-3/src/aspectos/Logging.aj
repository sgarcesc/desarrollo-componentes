package aspectos;

import java.util.List; 
import org.pl.eshop.dto.*;

public aspect Logging {
	String mensajeAgregarCategorias = "Se ha llamado al m�todo para agregar categorias";
	pointcut llamadaAgregar() : call(void *.agregar(Categoria));
	
	//advice
	before() : llamadaAgregar(){
		System.out.println(mensajeAgregarCategorias);
	}
	
	String mensajeModificarCategorias = "Se ha llamado al m�todo para modificar categorias";
	pointcut llamadaModificar() : call(void *.modificar(Categoria));
	
	//advice
	before() : llamadaModificar() {
		System.out.println(mensajeModificarCategorias);
	}
	
	String mensajeObtenerCategorias = "Se ha llamado al m�todo para obtener todas las categorias";
	pointcut llamadaObtenerTodas() : call(List<Categoria> *.obtenerTodas());
	
	//advice
	before() : llamadaObtenerTodas() {
		System.out.println(mensajeObtenerCategorias);
	}
	
	String mensajeObtenerCategoriaPorId = "Se ha llamado al m�todo para obtener una categoria por Id";
	pointcut llamadaObtenerPorId() : call(Categoria *.ObtenerPorId(Integer));
	
	//advice
	before() : llamadaObtenerPorId() {
		System.out.println(mensajeObtenerCategoriaPorId);
	}
	
	String mensajeEliminarCategoria = "Se ha llamado al m�todo eliminar categoria";
	pointcut llamadaEliminar() : call(void *.eliminar(Categoria));
	
	//advice
	before() : llamadaEliminar() {
		System.out.println(mensajeEliminarCategoria);
	}
}
