require 'build_utilities.rb'
require 'local_properties.rb'
require 'project.rb'
require 'rake/clean'
require 'fileutils'

#load settings that differ by machine
local_settings = LocalSettings.new

COMPILE_TARGET = 'debug'

CLEAN.include('artifacts/*.*','**/bin','**/obj','**/*.sql')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

template_files = TemplateFileList.new('**/*.template')
template_code_dir = File.join('product','templated_code')


#configuration files
config_files = FileList.new(File.join('product','config','*.template')).select{|fn| ! fn.include?('app.config')}
app_config = TemplateFile.new(File.join('product','config',local_settings[:app_config_template]))

#target folders that can be run from VS
project_startup_dir  = File.join('product',"#{Project.startup_dir}")
project_specs_dir  = Project.specs_dir
output_folders = [project_startup_dir,project_specs_dir]

task :default => ["specs:run"]

task :init  => :clean do
  cp_r "thirdparty/machine.specifications/.","artifacts"
  mkdir Project.specs_dir if ! File.exists?(Project.specs_dir)
  mkdir Project.report_folder if ! File.exists?(Project.report_folder)
end

desc 'expands all of the template files in the project'
task :expand_all_template_files do
  template_files.generate_all_output_files(local_settings.settings)
end

desc 'builds the database'
task :build_db => :expand_all_template_files do
    sql_runner.process_sql_files(create_sql_fileset('ddl'))
end

desc 'load the database'
task :load_data => :build_db do
    sql_runner.process_sql_files(create_sql_fileset('data'))
end

desc 'compiles the project'
task :compile => :expand_all_template_files do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => 'solution.sln'
end

task :from_ide  do
  app_config.generate_to(File.join(project_startup_dir,"#{Project.startup_config}"),local_settings.settings)
  Project.spec_assemblies.each do |assembly|
      app_config.generate_to(File.join(project_specs_dir,"#{File.basename(assembly)}.config"),local_settings.settings)
  end

  config_files.each do |file|
    TemplateFile.new(file).generate_to_directories([project_startup_dir,project_specs_dir],local_settings.settings)
  end
end

namespace :specs do
  desc 'view the spec report'
  task :view do
    system "start #{Project.report_folder}/#{Project.name}.specs.html"
  end

  desc 'run the specs for the project'
  task :run  => [:init,:compile] do
    sh "artifacts/mspec.exe", "--html", "#{Project.report_folder}/#{Project.name}.specs.html", "-x", "example", *([] + Project.spec_assemblies)
  end
end

desc "open the solution"
task :sln do
  Thread.new do
    system "devenv solution.sln"
  end
end
