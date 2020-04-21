<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="ID" prop="ID">
          <a-input v-model="entity.ID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CategoryID" prop="CategoryID">
          <a-input v-model="entity.CategoryID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Titile" prop="Titile">
          <a-input v-model="entity.Titile" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Time" prop="Time">
          <a-input v-model="entity.Time" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Money" prop="Money">
          <a-input v-model="entity.Money" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Remarks" prop="Remarks">
          <a-input v-model="entity.Remarks" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UpdateUserID" prop="UpdateUserID">
          <a-input v-model="entity.UpdateUserID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UpdateTime" prop="UpdateTime">
          <a-input v-model="entity.UpdateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="MoneyFormula" prop="MoneyFormula">
          <a-input v-model="entity.MoneyFormula" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="RecordTypeSourceID" prop="RecordTypeSourceID">
          <a-input v-model="entity.RecordTypeSourceID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CreateType" prop="CreateType">
          <a-input v-model="entity.CreateType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Code" prop="Code">
          <a-input v-model="entity.Code" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/Bill/IsMatch_MoneyChange/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/Bill/IsMatch_MoneyChange/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
